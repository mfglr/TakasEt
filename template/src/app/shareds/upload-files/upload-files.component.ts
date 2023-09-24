import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { fromEvent, mergeMap } from 'rxjs';
import { FileHelper } from 'src/app/helpers/file-helpers';
import { ContainerName } from 'src/app/models/containerName';
import { BlobService } from 'src/app/services/blob.service';

@Component({
  selector: 'app-upload-files',
  templateUrl: './upload-files.component.html',
  styleUrls: ['./upload-files.component.scss']
})
export class UploadFilesComponent {

  @ViewChild("submit",{static : true}) submit? : ElementRef;
  @Input() files? : File[]
  @Input() containerName? : ContainerName
  @Input() ownerId? : string;

  constructor(private blobService:BlobService) {

  }

  ngOnInit(): void {
    fromEvent(this.submit?.nativeElement,"click").pipe(
      mergeMap( () => {
        return this.blobService.upload(
          FileHelper.createFormData(
            this.files!,
            this.containerName!,
            this.ownerId!
          )
        )
      })
    ).subscribe(x => {
      console.log(x);
    })
  }
}
