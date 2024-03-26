import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Photo } from '@capacitor/camera';
import { PhotoService } from 'src/app/services/photo-service';
import { ChatState, UserState } from '../../state/reducer';
import { Store } from '@ngrx/store';
import { ChatHubService } from 'src/app/services/chat-hub.service';
import { FormControl } from '@angular/forms';
import { CreateMessage } from '../../models/request/create-message';
import { Router } from '@angular/router';
import { NavController } from '@ionic/angular';
import { createMessageAction } from '../../state/actions';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { first } from 'rxjs';

@Component({
  selector: 'app-add-photos',
  templateUrl: './add-photos.page.html',
  styleUrls: ['./add-photos.page.scss'],
})
export class AddPhotosPage implements OnInit{
  @ViewChild("swiper") swiper? : ElementRef;
  userState : UserState | null = null;
  messageInput = new FormControl<string>("");

  constructor(
    private readonly photoService : PhotoService,
    private readonly chatHub : ChatHubService,
    private readonly loginStore : Store<LoginState>,
    private readonly chatStore : Store<ChatState>,
    private navController: NavController,
    private readonly router : Router
  ) {
    this.userState = this.router.getCurrentNavigation()?.extras.state as (UserState | null);
  }


  photos : Photo[] = [];

  async ngOnInit() {
    this.takePhoto();
  }

  ngAfterViewChecked(){
    this.swiper?.nativeElement.swiper.update();
  }

  sendMessage(){
    this.loginStore.select(selectUserId).pipe(first()).subscribe(senderId => {
      if(this.photos.length > 0 && this.userState){
        var request : CreateMessage = {
          id : crypto.randomUUID(),
          content : this.messageInput.value ?? undefined,
          receiverId : this.userState.id,
          sendDate : new Date().getTime(),
        }
        this.chatStore.dispatch(createMessageAction({
          paths : this.photos.map( (x) => ({webPath : x.webPath!,format : x.format})),
          message : request,
          userState : this.userState,
          senderId : senderId!
        }))

        this.navController.back();

        this.messageInput.setValue('');
      }
    })


  }

  takePhoto(){
    this.photoService.takeAPhoto()
      .then(photo => {
        this.photos.push(photo);
        var swiperContainer = this.swiper?.nativeElement.swiper;
        if(swiperContainer && this.photos.length > 0)
          swiperContainer.activeIndex = this.photos.length - 1
      })
      .catch((e) => console.log(e));
  }

  removePhoto(index : number){
    if(index > -1 && index < this.photos.length){
      this.photos.splice(index,1);
    }
  }

}
