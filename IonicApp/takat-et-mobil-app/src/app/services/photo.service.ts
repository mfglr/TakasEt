import { Injectable } from '@angular/core';
import { Camera, CameraResultType, CameraSource } from '@capacitor/camera';
import { Observable, from, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhotoService {
  
  constructor() { }

  public takeAPhoto() : Observable<string>{
    return from(
      Camera.getPhoto({
        resultType: CameraResultType.Uri, source: CameraSource.Camera, quality: 100
      })
    ).pipe(
      map(capturedPhoto => capturedPhoto.webPath!)
    )
  }
}
