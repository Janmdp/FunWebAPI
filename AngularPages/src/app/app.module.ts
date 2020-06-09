import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { ToastrModule } from "ngx-toastr";
import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { UserComponent } from './users/user/user.component';
import { UserService } from './shared/users/user.service';
import { UserListComponent } from './users/user-list/user-list.component';
import { LoginComponent } from './users/login/login.component';
import { ShiftsComponent } from './shifts/shifts.component';
import { ShiftComponent } from './shifts/shift/shift.component';
import { ShiftListComponent } from './shifts/shift-list/shift-list.component';
import { CookieService } from 'ngx-cookie-service';
import { ShiftService } from './shared/shifts/shift.service';
import { RosterService } from './shared/rosters/roster.service';
import { TradeService } from './shared/trades/trade.service';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    UserComponent,
    UserListComponent,
    LoginComponent,
    ShiftsComponent,
    ShiftComponent,
    ShiftListComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    AppRoutingModule,
  ],
  providers: [UserService,  ShiftService, RosterService, TradeService, CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
