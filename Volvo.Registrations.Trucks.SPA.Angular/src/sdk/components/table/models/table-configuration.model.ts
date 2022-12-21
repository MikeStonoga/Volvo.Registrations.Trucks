import { HttpErrorResponse } from "@angular/common/http";
import { EventEmitter } from "@angular/core";
import { Observable } from "rxjs";

export class TableConfiguration<TData> {
  public get dataSource(): GetAllForListDTOResult<TData> { return this._dataSource; };
  private _dataSource!: GetAllForListDTOResult<TData>;

  public get required(): RequiredTableConfiguration<TData> { return this._required; };
  public get optional(): OptionalTableConfiguration<TData> { return this._optional; };

  private _required: RequiredTableConfiguration<TData>;
  private _optional: OptionalTableConfiguration<TData>;

  constructor(requiredConfiguration: RequiredTableConfiguration<TData>, optionalConfiguration?: IOptionalTableConfiguration<TData>) {
    this._required = requiredConfiguration;
    this._optional = new OptionalTableConfiguration(this.required, optionalConfiguration);
    this.getData();
  }

  public getData() {
    this.required.actions.getData(this.optional.parametrosDaBuscaDeDados)
      .subscribe(response => {
        if (response instanceof HttpErrorResponse) {
          return;
        }
        this._dataSource = response
    })
  }
}

export interface RequiredTableConfiguration<TData> {
  columns: TableColumnsConfiguration<TData>;
  actions: TableActionsConfiguration<TData>
}

export interface TableColumnsConfiguration<TData> {
  definitions: TableColumnConfiguration<TData>[];
  defaultSort: SortConfiguration;
}

export interface TableColumnConfiguration<TData> {
  title: string;
  propertyName: string;
  type?: TableColumnType;
  disableSort?: boolean;
  transform?: (data: TData) => any;
  onClick?: (data: TData) => void;
}

export type TableColumnType = 'text' | 'link' | 'date' | 'datetime';

export interface SortConfiguration {
  columnName: string;
  direction: 'asc' | 'desc';
}

export interface TableActionsConfiguration<TData> {
  getData: (options: GetAllForListDTORequirement) => Observable<GetAllForListDTOResult<TData>>;
}

export interface GetAllForListDTOResult<TData> {
  totalCount: number;
  data: TData[]; 
}



export interface IOptionalTableConfiguration<TData> {
  defaultPagination?: PaginationConfiguration;
  defaultSort?: SortConfiguration;
  defaultFilter?: string;

}

export class OptionalTableConfiguration<TData> {
  public get parametrosDaBuscaDeDados(): GetAllForListDTORequirement { return this._parametrosDaBuscaDeDados; };
  private _parametrosDaBuscaDeDados: GetAllForListDTORequirement;

  constructor(required: RequiredTableConfiguration<TData>, input?: IOptionalTableConfiguration<TData>) {
    this._parametrosDaBuscaDeDados = new GetAllForListDTORequirement(
      input?.defaultFilter ?? '',
      input?.defaultSort ?? required.columns.defaultSort,
      input?.defaultPagination ?? { skipCount: 0, pageSize: 10 }
    );
  }
}

export class GetAllForListDTORequirement {
  public filterValue(): string { return this.filter; };
  public sortConfiguration(): SortConfiguration { return this.sort };
  public paginationConfiguration(): PaginationConfiguration { return this.pagination; }
  
  private idsToIgnore: string[] = [];
  private filter: string;
  private sort: SortConfiguration;
  private pagination: PaginationConfiguration;

  constructor(filter: string, sort: SortConfiguration, pagination: PaginationConfiguration) {
    this.filter = filter;
    this.sort = sort;
    this.pagination = pagination;
  }

  public changeFilter(filter: string) {
    this.filter = filter;
  }

  public changeSort(sort: SortConfiguration) {
    this.sort = sort;
  }

  public changePagination(pagination: PaginationConfiguration) {
    this.pagination = pagination;
  }
  public anexarIdsParaIgnorar(idsParaIgnorar: string[]) {
    this.idsToIgnore = idsParaIgnorar;
  }
}

export interface PaginationConfiguration {
  skipCount: number;
  pageSize: number;
}

