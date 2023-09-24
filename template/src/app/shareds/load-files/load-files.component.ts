import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-load-files',
  templateUrl: './load-files.component.html',
  styleUrls: ['./load-files.component.scss']
})
export class LoadFilesComponent implements OnInit {

  @ViewChild("fileInput",{static : true}) fileInut? : ElementRef;
  @Output() files = new EventEmitter<File[]>();

  fileUploadForm = new FormGroup({
    fileInput : new FormControl()
  })

  get fileInputControl(){
    return this.fileUploadForm.get('fileInput');
  }

  ngOnInit(){
    this.fileUploadForm.valueChanges.subscribe( () => {
      this.files.emit(this.fileInut?.nativeElement.files);
      this.fileInputControl?.patchValue(null,{onlySelf : true});
    })
  }
}
