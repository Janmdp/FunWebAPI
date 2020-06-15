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
import { TradeService } from './shared/trades/trade.service';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './pages/home/home.component';
import { NavbarComponent } from './pages/Misc/navbar/navbar.component';
import { UserProfileComponent } from './users/user-profile/user-profile.component';
import { UserUpdateComponent } from './users/user-update/user-update.component';
import { TradeListComponent } from './trades/trade-list/trade-list.component';
import { TradeComponent} from './pages/trade/trade.component';
import { TradeCreateComponent } from './trades/trade-create/trade-create.component'



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
    HomeComponent,
    NavbarComponent,
    UserProfileComponent,
    UserUpdateComponent,
    TradeComponent,
    TradeListComponent,
    TradeCreateComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    AppRoutingModule,
  ],
  providers: [UserService,  ShiftService, TradeService, CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
