import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { IonModal } from '@ionic/angular';
import { PostResponse } from 'src/app/models/responses/post-response';

@Component({
  selector: 'app-post-detail-modal',
  templateUrl: './post-detail-modal.component.html',
  styleUrls: ['./post-detail-modal.component.scss'],
})
export class PostDetailModalComponent{
  
  @ViewChild(IonModal) modal?: IonModal;
  @Input() post? : PostResponse | null;
  @Input() isModalOpen : boolean | null = null;
  @Output() closeModalEvent = new EventEmitter();
  constructor(
  ) { }

  closeModal(){
    this.isModalOpen = false;
    this.closeModalEvent.emit()
  }
}