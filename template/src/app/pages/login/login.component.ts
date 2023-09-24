import { Component, ElementRef, EventEmitter, OnDestroy, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Subscription, fromEvent, mergeMap, withLatestFrom } from 'rxjs';
import { AccessTokenProviderService } from 'src/app/services/access-token-provider.service';
import { AppStringsService } from 'src/app/services/app-strings.service';
import { LoggedInUserService } from 'src/app/services/logged-in-user.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit,OnDestroy {

  @ViewChild("submit",{static :true}) private submit? : ElementRef;
  @Output() login : EventEmitter<boolean> = new EventEmitter<boolean>();

  public loginForm : FormGroup = new FormGroup({
    email : new FormControl(''),
    password : new FormControl('')
  });

  private loginFormSubscription? : Subscription;

  constructor(
    public appStringsService : AppStringsService,
    private userService : UserService,
    private accessTokenProvider : AccessTokenProviderService,
    private loggedInUser : LoggedInUserService) {
  }

  ngOnDestroy(): void {
    this.loginFormSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    
    this.loginFormSubscription = fromEvent(this.submit?.nativeElement,"click").pipe(
      withLatestFrom(this.loginForm.valueChanges),
      mergeMap(([event,login]) => {
        this.loggedInUser.email = login.email
        return this.userService.login(login.email,login.password)
      })
    ).subscribe(response => {
      this.accessTokenProvider.setAccessToken(response.data?.accessToken);
      this.login.emit(true);
    });

  }
}
