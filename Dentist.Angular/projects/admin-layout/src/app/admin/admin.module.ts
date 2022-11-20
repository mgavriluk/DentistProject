import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AdminRoutingModule } from "./admin-routing.module";
import { FooterComponent } from "../components/footer/footer.component";
import { HeaderComponent } from "../components/header/header.component";
import { AdminDashboardComponent } from "../components/admin-dashboard/admin-dashboard.component";
import { HomeComponent } from "../pages/home/home.component";
import { MaterialModule } from "../material/material.module";
import { DentistServicesComponent } from "../pages/dentist-services/dentist-services.component";
import { AddServiceDialogComponent } from "../components/add-service-dialog/add-service-dialog.component";
import { ReactiveFormsModule } from "@angular/forms";
import { ClientsComponent } from "../pages/clients/clients.component";
import { DiscountsComponent } from "../pages/discounts/discounts.component";

@NgModule({
  declarations: [
    FooterComponent,
    HeaderComponent,
    AdminDashboardComponent,
    HomeComponent,
    DentistServicesComponent,
    AddServiceDialogComponent,
    ClientsComponent,
    DiscountsComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
})
export class AdminModule {}
