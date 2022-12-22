import { AfterViewInit, ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { TableConfiguration, TableColumnConfiguration } from './models/table-configuration.model';

@Component({
  selector: 'my-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent<TData> implements OnInit, AfterViewInit {
  @Input() configuration!: TableConfiguration<TData>;
  @Output() refreshed: EventEmitter<void> = new EventEmitter<void>();

  public get displayedColumns(): string[] { 
    const informedColumns = this.configuration.required.columns.definitions.map(e => e.title);
    if (this.hasCustomRowActions)
      informedColumns.push('Actions');
    return informedColumns; 
  };
  public get hasCustomRowActions(): boolean { return (this.configuration.required.actions.custom?.length ?? 0) > 0; }
  public get dataSource(): TData[] { return this.configuration.dataSource?.data; } 
  public get quantityOfRegistries(): number { return this.configuration.dataSource?.totalCount; }
  public get hasRegistries(): boolean { return this.quantityOfRegistries > 0; }
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  public filter: string = '';
  constructor(
    private readonly changeDetector: ChangeDetectorRef
  ) {

  }

  ngOnInit() {
    this.refreshList();
   
  }
  refreshList() {
    this.configuration.getData();
    this.refreshed.emit();
  }

  ngAfterViewInit() {
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.filter = filterValue.trim().toLowerCase();
    this.configuration.optional.parametrosDaBuscaDeDados.changeFilter(this.filter);

    if (this.paginator) {
      this.paginator.firstPage();
    }
  }

  public getColumnData(column: TableColumnConfiguration<TData>, row: any) {
    return row[column.propertyName];
  }

  public sortData($event: any) {
    this.configuration.optional.parametrosDaBuscaDeDados.changeSort({
      columnName: $event.active, 
      direction: $event.direction
    });
    this.configuration.getData();
  }

  public paginateData($event: PageEvent) {
    this.configuration.optional.parametrosDaBuscaDeDados.changePagination({
      pageSize: $event.pageSize,
      skipCount: $event.pageIndex  * $event.pageSize
    });
    this.configuration.getData();
  }
}
