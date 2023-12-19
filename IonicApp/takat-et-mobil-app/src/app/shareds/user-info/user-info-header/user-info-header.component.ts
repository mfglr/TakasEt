import { Component, Input } from '@angular/core';
import { UserResponse } from 'src/app/models/responses/user-response';

@Component({
  selector: 'app-user-info-header',
  templateUrl: './user-info-header.component.html',
  styleUrls: ['./user-info-header.component.scss'],
})
export class UserInfoHeaderComponent{
  @Input() user? : UserResponse | null;
}
