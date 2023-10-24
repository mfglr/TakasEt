import { AfterContentInit, Component, ElementRef, OnDestroy, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Subscription, fromEvent, mergeMap, withLatestFrom } from 'rxjs';
import { AppStringsService } from 'src/app/services/app-strings.service';
import { login } from 'src/app/states/user/actions';
import { UserState } from 'src/app/states/user/state';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnDestroy, AfterContentInit {

  @ViewChild("submit",{static : true}) submit? : ElementRef;
  private subscription? : Subscription;
  public loginForm : FormGroup = new FormGroup({
    email : new FormControl(''),
    password : new FormControl('')
  });

  constructor(
    public appStringsService : AppStringsService,
    private store : Store<UserState>) {
  }

  ngAfterContentInit(): void {
    this.subscription = fromEvent(this.submit?.nativeElement,"click").pipe(
      withLatestFrom(this.loginForm.valueChanges)
    ).subscribe(([_,value]) => {
      this.store.dispatch(login({email : value.email, password : value.password}))
    });
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

}
