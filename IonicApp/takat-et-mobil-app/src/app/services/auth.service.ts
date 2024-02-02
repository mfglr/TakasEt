import { Injectable } from "@angular/core";
import { NativeHttpClientService } from "./native-http-client.service";
import { UserManager } from "oidc-client";

@Injectable({ providedIn : "root" })
export class AuthService{

  private config = {
    authority : "https://localhost:7293",
    client_id : "ionic_app",
    redirect_uri : "http://localhost:8100/callback",
    scope : "PhotoStockMicroservice.UserImages.read PhotoStockMicroservice.PostImages.read API.read",
    post_logout_redirect_uris : "http://localhost:8100"

  }

  userManager : UserManager;

  constructor(private httpClient : NativeHttpClientService) {
    this.userManager = new UserManager(this.config);
  }






}
