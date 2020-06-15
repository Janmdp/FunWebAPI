import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component'
import { LoginComponent } from './users/login/login.component'
import { AuthGuard } from './auth/auth.guard';
import { UsersComponent } from './users/users.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { UserComponent } from './users/user/user.component';
import { UserUpdateComponent } from './users/user-update/user-update.component';
import { UserProfileComponent } from './users/user-profile/user-profile.component';
import { TradeListComponent } from './trades/trade-list/trade-list.component';
import { TradeComponent } from './pages/trade/trade.component';


const routes: Routes = [
  { path: '', component: LoginComponent},
  { path: 'login', component: LoginComponent},
  { path: 'home', component: HomeComponent, canActivate:[AuthGuard] },
  { path: 'profile', component: UserProfileComponent, canActivate:[AuthGuard]},
  { path: 'update', component: UserUpdateComponent, canActivate:[AuthGuard]},
  { path: 'trades', component: TradeComponent, canActivate:[AuthGuard]},
  { path: 'register', component: UserComponent, canActivate:[AuthGuard]}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
