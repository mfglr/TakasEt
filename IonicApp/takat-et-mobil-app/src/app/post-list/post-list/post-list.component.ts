import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectIsModalOpen, selectPostId, selectPostOfModal } from '../state/selectors';
import { PostListState } from '../state/reducer';
import { closeModalAction } from '../state/actions';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss'],
})
export class PostListComponent {

  @Input() postIds? : number[] | null;

  postId$ = this.postListStore.select(selectPostId);
  postOfModal$ = this.postListStore.select(selectPostOfModal);
  isModalOpen$ = this.postListStore.select(selectIsModalOpen);

  constructor(
    private postListStore : Store<PostListState>,
  ) {}

  closeModal(){
    this.postListStore.dispatch(closeModalAction())
  }
}
