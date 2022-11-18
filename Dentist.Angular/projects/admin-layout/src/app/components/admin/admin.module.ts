import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AdminRoutingModule } from "./admin-routing.module";
import { FooterComponent } from "../footer/footer.component";
import { HeaderComponent } from "../header/header.component";
import { AdminDashboardComponent } from "../admin-dashboard/admin-dashboard.component";
import { HomeComponent } from "../home/home.component";
import { MaterialModule } from "../../material/material.module";
import { DentistServicesComponent } from "../dentist-services/dentist-services.component";
import { AddServiceDialogComponent } from "../add-service-dialog/add-service-dialog.component";
import { ReactiveFormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    FooterComponent,
    HeaderComponent,
    AdminDashboardComponent,
    HomeComponent,
    DentistServicesComponent,
    AddServiceDialogComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
})
export class AdminModule {}
