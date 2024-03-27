import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, map } from 'rxjs';
import { LoginState } from 'src/app/account/state/reducer';
import { selectUserId } from 'src/app/account/state/selectors';
import { loadMessageImageAction } from 'src/app/chat/state/actions';
import { ChatState, MessageState } from 'src/app/chat/state/reducer';
import { ImageLoadingState } from 'src/app/models/enums/image-loading-state';

@Component({
  selector: 'app-message-box',
  templateUrl: './message-box.component.html',
  styleUrls: ['./message-box.component.scss'],
})
export class MessageBoxComponent{

  @Input() message? : MessageState;
  loaded = ImageLoadingState.loaded;
  imageLodingTemplateStyle? : string;
  contentStyle$? : Observable<string>;

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

  imageStyle$ = this.isMyMessage$.pipe(
    map(isMyMessage => {
      if(isMyMessage)
        return "border-top-left-radius: 0.8rem"
      return "border-top-right-radius:0.8rem"
    })
  )

  footerStyle$ = this.isMyMessage$.pipe(
    map(x => {
      if(x) return "justify-content: space-between;align-items: center;";
      return "flex-direction : row-reverse;"
    })
  )

  constructor(
    private readonly loginStore : Store<LoginState>,
    private readonly chatStore : Store<ChatState>
  ) { }

  private hasImage(){
    return this.message && this.message.images && this.message.images.length > 0;
  }

  ngOnInit(){
    if(this.hasImage()){
      this.chatStore.dispatch(loadMessageImageAction({
        id : this.message!.id,
        imageIndex : 0,
        blobName : this.message!.images![0].blobName!,
        extention : this.message!.images![0].extention!
      }))
      this.imageLodingTemplateStyle = `width:100%;aspect-ratio:${this.message!.images![0].aspectRatio}`
    }
  }

  ngOnChanges(){
    this.contentStyle$ = this.isMyMessage$.pipe(
      map(isMyMessage => {
        let messageBoxWidth = this.hasImage() ? 'width:90%' : '';
        if(isMyMessage)
          return `border-top-right-radius:0rem;${messageBoxWidth}`
        return `border-top-left-radius:0rem;${messageBoxWidth}`
      })
    )
  }

}
