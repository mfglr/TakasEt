import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { fromEvent, mergeMap } from 'rxjs';
import { FormDataHelper } from 'src/app/helpers/formData-helpers';
import { ContainerName } from 'src/app/models/enums/containerName';
import { FileService } from 'src/app/services/file.service';

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

  constructor(private fileService:FileService) {

  }

  ngOnInit(): void {
    fromEvent(this.submit?.nativeElement,"click").pipe(
      mergeMap( () => {
        return this.fileService.upload(
          FormDataHelper.createFormDataForUploadFiles(
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
