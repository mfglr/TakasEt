import { Component } from '@angular/core';
import { ChatState, MessageState } from '../../state/reducer';
import { Store } from '@ngrx/store';
import { loadMessageImageAction } from '../../state/actions';
import { ImageLoadingState } from 'src/app/models/enums/image-loading-state';
import { selectMessageState } from '../../state/selectors';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-display-message',
  templateUrl: './display-message.page.html',
  styleUrls: ['./display-message.page.scss'],
})
export class DisplayMessagePage{

  private readonly messageId : string;
  message$ : Observable<MessageState | undefined>;
  loaded = ImageLoadingState.loaded;

  constructor(
    private readonly router : Router,
    private readonly chatStore : Store<ChatState>
  ) {
    var state = this.router.getCurrentNavigation()?.extras.state as ({messageId : string});
    this.messageId = state.messageId
    this.message$ = this.chatStore.select(selectMessageState({messageId : this.messageId}));
  }

  ngOnInit(){
    this.message$.subscribe(message => {
      if(message && message.images){
        message.images.forEach((image,index) => {
          this.chatStore.dispatch(loadMessageImageAction({
            id : message.id,
            blobName : image.blobName!,
            extention : image.extention!,
            imageIndex : index
          }));
        })
      }
    })
  }


}
