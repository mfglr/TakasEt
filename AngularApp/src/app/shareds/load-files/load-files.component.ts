import { Component, ElementRef, EventEmitter, OnDestroy, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable, map, mergeMap, of } from 'rxjs';

@Component({
  selector: 'app-load-files',
  templateUrl: './load-files.component.html',
  styleUrls: ['./load-files.component.scss']
})
export class LoadFilesComponent{

  @ViewChild("fileInput",{static : true}) fileInut? : ElementRef;
  @Output() filesEvent = new EventEmitter<{file : File,url : string}[]>();
  files : {file : File,url : string}[] = [];

  fileUploadForm = new FormGroup({
    fileInput : new FormControl()
  })

  ngOnInit(){
    this.fileUploadForm.valueChanges.pipe(
      mergeMap( () : Observable<File[]> => of(this.fileInut?.nativeElement.files) ),
      map((x) : {file : File,url : string}[] =>{
        for(let i = 0; i < x.length; i++)
          this.files.push({ file : x[i], url : URL.createObjectURL(x[i]) })
        return this.files;
      })
    ).subscribe(() => {
      this.filesEvent.emit(this.files);
      this.fileUploadForm.get('fileInput')?.setValue(null,{onlySelf : true});
    })
  }

}
