import { AfterContentInit, Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Subscription, fromEvent, mergeMap } from 'rxjs';
import { FormDataHelper } from 'src/app/helpers/formData-helpers';
import { Mode } from 'src/app/helpers/mode';
import { ContainerName } from 'src/app/models/enums/containerName';
import { PostService } from 'src/app/services/post.service';
import { selectUserId } from 'src/app/states/login_state/selectors';
import { AppLoginState } from 'src/app/states/login_state/state';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.scss']
})
export class CreatePostComponent implements OnInit,OnDestroy,AfterContentInit{

  public mode : Mode;
  public files : {file : File, url : string}[] = [];
  public containerName = ContainerName.postImage;
  private subscirptionUserId? : Subscription;
  @ViewChild("submit",{static: true}) private submit? :ElementRef;

  public createPostForm : FormGroup = new FormGroup({
    userId : new FormControl<string | null>(null),
    categoryId : new FormControl<string | null>(null),
    title : new FormControl<string | null>(null),
    content : new FormControl<string | null>(null),
    files : new FormControl<File[] | null >(null)
  })

  constructor(
    private store: Store<AppLoginState>,
    private postService: PostService
  ) {
    this.mode = new Mode(this.files.length + 1);
  }

  ngOnInit(): void {
    this.subscirptionUserId = this.store.select(selectUserId).subscribe(id => {
      if(id) this.createPostForm.get('userId')?.setValue(id)
    });
  }

  ngAfterContentInit(){
    fromEvent(this.submit?.nativeElement,'click').pipe(
      mergeMap( () => {
          let formData = FormDataHelper.createFormDataForAddPost(this.createPostForm.value)
          return this.postService.addPost(formData);
        }
      ),
    ).subscribe(x => console.log(x));
  }

  ngOnDestroy(): void {
    this.subscirptionUserId?.unsubscribe();
  }

  anyUrl(){
    return this.files && this.files.length != 0
  }

  getCategoryId(categoryId : number){
    this.createPostForm.get('categoryId')?.setValue(categoryId);
  }

  getFiles(files : {file : File,url : string}[]){
    this.createPostForm.get('files')?.setValue(files.map(x => x.file))
    this.files = files;
    this.mode = new Mode(files.length + 1);
  }
}
