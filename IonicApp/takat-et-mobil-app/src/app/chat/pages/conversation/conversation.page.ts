import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, Subscription, filter, first, from, mergeMap } from 'rxjs';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { ChatState, MessageState, UserState, numberOfMessagesPerPage } from '../../state/reducer';
import { nextPageMessagesAction, createMessageAction } from '../../state/actions';
import { selectMessageStatesOfConversatinPage, selectUnviewedMessages } from '../../state/selectors';
import { Router } from '@angular/router';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { CreateMessage } from '../../models/request/create-message';
import { FormControl } from '@angular/forms';
import { IonContent, Platform, ScrollDetail } from '@ionic/angular';

@Component({
  selector: 'app-conversation',
  templateUrl: './conversation.page.html',
  styleUrls: ['./conversation.page.scss'],
})
export class ConversationPage implements OnInit,OnDestroy {


  @ViewChild(IonContent) content? : IonContent;
  @ViewChild("scrollContainer") scrollContainer? : ElementRef;
  numberOfMessages : number = 0;

  userState : UserState | undefined = undefined;
  subcription? : Subscription;
  scrollSubscription? : Subscription;
  messages$? : Observable<MessageState[]>
  messageInput = new FormControl<string>("");

  constructor(
    private readonly chatHub : ChatHubService,
    private readonly chatStore : Store<ChatState>,
    private readonly loginStore : Store<LoginState>,
    private readonly router : Router,
  ) {
    var state = this.router.getCurrentNavigation()?.extras.state;
    if(state)
      this.userState = state as (UserState | undefined)
  }

  ngOnInit() {
    if(this.userState){
      this.messages$ = this.chatStore.select(selectMessageStatesOfConversatinPage({userId : this.userState.id}));

      this.scrollSubscription = this.messages$.subscribe(() => {
        setTimeout(() => this.scrollContainer!.nativeElement.scrollIntoView());
      })

      this.messages$.pipe(first()).subscribe(
        messages => {
          if(messages.length < numberOfMessagesPerPage)
            this.chatStore.dispatch(nextPageMessagesAction({user : this.userState!}))
        }
      )

      this.subcription = this.chatHub.unviewedMessages.pipe(
        filter(message => message.senderId == this.userState!.id)
      )
      .subscribe(message => this.chatHub.viewedMessagesSubject.next(message.id))

      this.chatStore.select(selectUnviewedMessages({userId : this.userState.id})).pipe(
        first(),
        mergeMap(messages => from(messages))
      )
      .subscribe(message => this.chatHub.viewedMessagesSubject.next(message.id))
    }
  }

  scrollBottom(){
    this.content?.scrollToBottom(500);
  }

  onScroll(e : CustomEvent<ScrollDetail>){
    console.log(e.detail.scrollTop);
  }

  ngAfterViewInit(){
    setTimeout(() => this.scrollContainer!.nativeElement.scrollIntoView());
  }

  ngOnDestroy(){
    this.subcription?.unsubscribe();
    this.scrollSubscription?.unsubscribe();
  }

  sendMessage(){
    this.loginStore.select(selectUserId).pipe(first()).subscribe(loginUserId => {
      if(this.messageInput.value && this.userState){

        var request : CreateMessage = {
          id : crypto.randomUUID(),
          content : this.messageInput.value,
          receiverId : this.userState.id,
          sendDate : new Date().getTime(),
          images : []
        }

        this.chatStore.dispatch(createMessageAction({
          senderId : loginUserId!,
          message : request,
          paths : [],
          userState : this.userState
        }))

        this.messageInput.setValue('');
        // setTimeout(() => this.scrollContainer!.nativeElement.scrollIntoView());
        this.scrollContainer!.nativeElement.scrollIntoView()

      }
    });

  }

}
