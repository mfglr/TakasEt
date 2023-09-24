import { Component } from '@angular/core';
import { Mode } from 'src/app/helpers/mode';
import { ContainerName } from 'src/app/models/containerName';

@Component({
  selector: 'app-display-images',
  templateUrl: './display-images.component.html',
  styleUrls: ['./display-images.component.scss']
})
export class DisplayImagesComponent {

  public mode : Mode;
  public files : File[] = []
  public urls : string[] = [];

  public containerName = ContainerName.postImage;
  public ownerId : string = "1270a259-3299-4245-c390-08dbbd274956";

  constructor() {
    this.mode = new Mode(this.urls.length + 1);
  }

  anyUrl(){
    return this.urls && this.urls.length != 0
  }

  getFiles(files : File[]){
    for(let i = 0; i < files.length; i++){
      this.files.push(files[i]);
      this.urls.push(URL.createObjectURL(files[i]))
    }
    this.mode = new Mode(this.files.length + 1);
  }
}
