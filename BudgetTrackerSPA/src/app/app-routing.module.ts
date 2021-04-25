import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserAddComponent } from './users/user-add/user-add.component';
import { UserDetailsComponent } from './users/user-details/user-details.component';


const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "users/new", component: UserAddComponent},
  {path: "users/:id", component: UserDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
