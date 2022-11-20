import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdminDashboardComponent } from "../components/admin-dashboard/admin-dashboard.component";
import { ClientsComponent } from "../pages/clients/clients.component";
import { DentistServicesComponent } from "../pages/dentist-services/dentist-services.component";
import { DentistServicesResolver } from "../pages/dentist-services/dentist-services.resolver";
import { DiscountsComponent } from "../pages/discounts/discounts.component";
import { HomeComponent } from "../pages/home/home.component";

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
        resolve: {
          dentistServices: DentistServicesResolver,
        },
      },
      {
        path: "clients",
        component: ClientsComponent,
      },
      {
        path: "discounts",
        component: DiscountsComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
