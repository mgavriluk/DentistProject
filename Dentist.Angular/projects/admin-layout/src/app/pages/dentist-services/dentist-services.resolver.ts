import { Injectable } from "@angular/core";
import {
  Router,
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from "@angular/router";
import { Observable, of } from "rxjs";
import { IDentistService } from "../../models/dentist-service";
import { IPaginatedResult } from "../../models/paginated-result";
import { AdminService } from "../../services/admin.service";

@Injectable({
  providedIn: "root",
})
export class DentistServicesResolver
  implements Resolve<IPaginatedResult<IDentistService>>
{
  constructor(private adminService: AdminService) {}
  resolve(
    route: ActivatedRouteSnapshot
  ): Observable<IPaginatedResult<IDentistService>> {
    const pageIndex = route.paramMap.get("PageIndex");
    const pageSize = route.paramMap.get("PageSize");
    const columnNameForSorting = route.paramMap.get("ColumnNameForSorting");
    const sortDirection = route.paramMap.get("SortDirection");

    return this.adminService.getDentistServices(
      +pageIndex,
      +pageSize,
      columnNameForSorting,
      sortDirection
    );
  }
}
