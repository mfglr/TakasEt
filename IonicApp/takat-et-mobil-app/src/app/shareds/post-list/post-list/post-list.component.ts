import { Component, Input } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectIsModalOpen, selectPostOfModal } from '../state/selectors';
import { State } from '../state/reducer';
import { closeModalAction } from '../state/actions';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss'],
})
export class PostListComponent {
  
  @Input() postIds? : number[] | null;

  constructor(
    private postListStore : Store<State>
  ) {}

  postOfModal$ = this.postListStore.select(selectPostOfModal);
  isModalOpen$ = this.postListStore.select(selectIsModalOpen);

  closeModal(){
    this.postListStore.dispatch(closeModalAction())  
  }
}
