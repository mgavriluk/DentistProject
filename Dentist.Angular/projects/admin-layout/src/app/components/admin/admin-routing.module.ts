import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminDashboardComponent } from "../admin-dashboard/admin-dashboard.component";
import { DentistServicesComponent } from "../dentist-services/dentist-services.component";
import { HomeComponent } from "../home/home.component";

const routes: Routes = [
  {
    path: "",
    component: AdminDashboardComponent,
    children: [
      {
        path: "",
        redirectTo: "home",
        pathMatch: "full",
      },
      {
        path: "home",
        component: HomeComponent,
      },
      {
        path: "dentist-services",
        component: DentistServicesComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
