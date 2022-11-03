import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

import { AdminLayoutRoutes } from "./admin-layout.routing";

import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { HomeComponent } from "app/pages/home/home.component";
import { NavbarModule } from "app/shared/navbar/navbar.module";
import { SidebarModule } from "app/sidebar/sidebar.module";
import { FooterComponent } from "app/shared/footer/footer.component";
import { FooterModule } from "app/shared/footer/footer.module";

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    NgbModule,
    NavbarModule,
    SidebarModule,
    FooterModule,
  ],
  declarations: [HomeComponent],
})
export class AdminLayoutModule {}
