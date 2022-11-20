import { NgModule } from "@angular/core";
import { MatTableModule } from "@angular/material/table";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatCardModule } from "@angular/material/card";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatMenuModule } from "@angular/material/menu";
import { MatSlideToggleModule } from "@angular/material/slide-toggle";
import { MatSelectModule } from "@angular/material/select";
import { MatOptionModule } from "@angular/material/core";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatListModule } from "@angular/material/list";
import { MatInputModule } from "@angular/material/input";
import { MatSortModule } from "@angular/material/sort";
import { MatDialogModule } from "@angular/material/dialog";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";

const modules = [
  MatTableModule,
  MatButtonModule,
  MatIconModule,
  MatCardModule,
  MatPaginatorModule,
  MatFormFieldModule,
  MatToolbarModule,
  MatMenuModule,
  MatInputModule,
  MatProgressSpinnerModule,
  MatListModule,
  MatSlideToggleModule,
  MatSelectModule,
  MatOptionModule,
  MatSidenavModule,
  MatSortModule,
  MatDialogModule,
];

@NgModule({
  providers: [],
  imports: [modules],
  exports: [modules],
})
export class MaterialModule {}
