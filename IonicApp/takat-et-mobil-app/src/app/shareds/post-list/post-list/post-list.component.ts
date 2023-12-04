import { Component, Input } from '@angular/core';
import { PostResponse } from 'src/app/models/responses/post-response';
import { selectIsModalOpen,selectPostOfModal } from '../state/selectors';
import { Store } from '@ngrx/store';
import { State } from '../state/reducer';
import { closeModalAction } from '../state/actions';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss'],
})
export class PostListComponent {
  
  @Input() posts? : PostResponse[] | null;
  
  postOfModal$ = this.postListStore.select(selectPostOfModal);
  isModalOpen$ = this.postListStore.select(selectIsModalOpen);

  constructor(
    private postListStore : Store<State>
  ) {}
  
  closeModal(){
    this.postListStore.dispatch(closeModalAction())  
  }

}
