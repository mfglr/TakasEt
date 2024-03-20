import { Injectable } from '@angular/core';
import { Camera, CameraResultType, CameraSource, Photo } from '@capacitor/camera';
import { Filesystem, Directory } from '@capacitor/filesystem';
import { Preferences } from '@capacitor/preferences';

@Injectable({ providedIn : "root" })
export class PhotoService{

  public takeAPhoto() {
    return Camera.getPhoto({
      resultType: CameraResultType.DataUrl,
      source: CameraSource.Camera,
      quality: 100
    });
  }

  public getPhotos() {
    Camera.pickImages({
      presentationStyle : "fullscreen",
      quality : 100,
      limit : 5
    }).then(a => {
      a.photos[0].path
    })
  }

}
