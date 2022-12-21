import { AfterViewInit, ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
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

  public get displayedColumns(): string[] { return this.configuration.required.columns.definitions.map(e => e.title); };
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
}
