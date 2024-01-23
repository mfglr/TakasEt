import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectIsModalOpen, selectPostOfModal } from '../state/selectors';
import { PostListState } from '../state/reducer';
import { closeModalAction } from '../state/actions';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss'],
})
export class PostListComponent {
  @ViewChild("postList",{static : true}) postList? : ElementRef;
  @Input() posts? : PostResponse[] | null;

  postOfModal$ = this.postListStore.select(selectPostOfModal);
  isModalOpen$ = this.postListStore.select(selectIsModalOpen);

  constructor(
    private postListStore : Store<PostListState>,
  ) {}

  closeModal(){
    this.postListStore.dispatch(closeModalAction())
  }

}
