import { AfterViewInit, Component, OnInit, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { IDentistService } from "../../models/dentist-service";
import { AdminService } from "../../services/admin.service";
import { PageEvent } from "@angular/material/paginator";
import { MatDialog } from "@angular/material/dialog";
import { AddServiceDialogComponent } from "../../components/add-service-dialog/add-service-dialog.component";

@Component({
  selector: "app-dentist-services",
  templateUrl: "./dentist-services.component.html",
  styleUrls: ["./dentist-services.component.css"],
})
export class DentistServicesComponent implements AfterViewInit {
  dentistServicesList: IDentistService[] = [];
  isBusy: boolean = false;
  total: number = 0;
  pageSize: number = 5;
  pageEvent: PageEvent;
  pageIndex: number = 0;
  constructor(private adminService: AdminService, private dialog: MatDialog) {}
  ngOnInit(): void {
    this.fetch();
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe((page) => {
      this.pageSize = page.pageSize;
      this.pageIndex = page.pageIndex;
      this.fetch();
    });
  }
  fetch() {
    this.isBusy = true;
    this.adminService
      .getDentistServices(this.pageIndex, this.pageSize, "", "")
      .subscribe((res) => {
        this.dentistServicesList = res.items;
        this.total = res.total;
        this.pageSize = res.pageSize;
        this.pageIndex = res.pageIndex;
      });
    this.isBusy = false;
  }
  displayedColumns: string[] = ["name", "price", "actions"];
  @ViewChild(MatPaginator) paginator: MatPaginator;

  openDialog() {
    this.dialog
      .open(AddServiceDialogComponent, {
        width: "30%",
      })
      .afterClosed()
      .subscribe((val) => {
        if (val === "save") {
          this.fetch();
        }
      });
  }

  editService(row) {
    this.dialog
      .open(AddServiceDialogComponent, {
        width: "30%",
        data: row,
      })
      .afterClosed()
      .subscribe((val) => {
        if (val === "update") {
          this.fetch();
        }
      });
  }

  deleteService(id: number) {
    if (confirm("Вы действительно хотите удалить услугу?")) {
      this.adminService.deleteDentistService(id).subscribe({
        next: () => {
          alert("Услуга удалена");
          this.fetch();
        },
        error: () => {
          alert("Ошибка");
        },
      });
    }
  }
}
