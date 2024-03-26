import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { map } from 'rxjs';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { loadMessageImageAction } from 'src/app/chat/state/actions';
import { ChatState, MessageState } from 'src/app/chat/state/reducer';

@Component({
  selector: 'app-message-box',
  templateUrl: './message-box.component.html',
  styleUrls: ['./message-box.component.scss'],
})
export class MessageBoxComponent{

  @Input() message? : MessageState;

  constructor(
    private readonly loginStore : Store<LoginState>,
    private readonly chatStore : Store<ChatState>
  ) { }

  ngOnInit(){
    if(this.message && this.message.images){
      this.message.images.forEach((image,index) => {
        this.chatStore.dispatch(loadMessageImageAction({
          id : this.message!.id,
          imageIndex : index,
          blobName : image.blobName!,
          extention : image.extention!
        }))
      })
    }
  }

  isMyMessage$ = this.loginStore.select(selectUserId).pipe(
    map(userId => this.message != undefined && this.message.senderId == userId)
  )

  rootStyle$ = this.isMyMessage$.pipe(
    map(isMyMessage => {
      if(isMyMessage)
        return "flex-direction : row-reverse;"
      return "flex-direction : row;"
    })
  )

  contentStyle$ = this.isMyMessage$.pipe(
    map(isMyMessage => {
      if(isMyMessage)
        return "border-top-right-radius:0;"
      return "border-top-left-radius:0rem;"
    })
  )

  footerStyle$ = this.isMyMessage$.pipe(
    map(x => {
      if(x) return "justify-content: space-between;align-items: center;";
      return "flex-direction : row-reverse;"
    })
  )



}
