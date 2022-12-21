import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { catchError, Observable, throwError } from "rxjs";
import { GetAllForListDTORequirement, GetAllForListDTOResult } from "../../../sdk/components/table/models/table-configuration.model";

export abstract class ReadOnlyHttpService<TEntity> {

  protected get baseUrl(): string { return `/api/${this.controllerName}`; }

  constructor(
    private readonly controllerName: string,
    protected readonly httpClient: HttpClient
  ) {

  }

  public getById(id: string): Observable<TEntity> {
    return this.httpClient.get<TEntity>(`${this.baseUrl}/GetById?id=${id}`)
      .pipe(catchError((error: HttpErrorResponse) => {
        return throwError(error)
      }));
  }

  public GetAll(): Observable<TEntity[]> {
    return this.httpClient.get<TEntity[]>(`${this.baseUrl}/GetAll`)
      .pipe(catchError((error: HttpErrorResponse) => {
          return throwError(error)
        })
      );
  }

  public getAllForList<TIEntity>(options: GetAllForListDTORequirement, idsParaIgnorar: string[] = []): Observable<GetAllForListDTOResult<TIEntity>> {
    options.anexarIdsParaIgnorar(idsParaIgnorar);
    return this.httpClient.post<GetAllForListDTOResult<TIEntity>>(`${this.baseUrl}/GetAllForList`, options);
  }
}
