export interface IPaginatedResult<T> {
  pageIndex: number;
  pageSize: number;
  items: T[];
  total: number;
}
