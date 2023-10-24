import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { GenericMode } from 'src/app/helpers/generic-mode';

@Component({
  selector: 'app-display-post-images',
  templateUrl: './display-post-images.component.html',
  styleUrls: ['./display-post-images.component.scss']
})
export class DisplayPostImagesComponent implements OnInit,OnChanges {


  @Input() urls? : string[] | null
  mode : GenericMode<string> = new GenericMode<string>();

  ngOnInit(): void {
    this.mode = new GenericMode<string>(this.urls)
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.mode = new GenericMode<string>(this.urls)
  }

}
