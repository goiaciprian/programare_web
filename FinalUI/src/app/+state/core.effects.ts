import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, switchMap, tap } from 'rxjs';
import { User } from '../models/user.model.ts';
import { ApartamenteService } from '../services/apartamente.service';
import * as CoreActions from './core.actions';

@Injectable()
export class CoreEffects {
  constructor(
    private action$: Actions<any>,
    private _service: ApartamenteService
  ) {}

  usersGetAll$ = createEffect(() =>
    this.action$.pipe(
      ofType(CoreActions.BeginLoadingUser),
      switchMap(() =>
        this._service.getAllUsers().pipe(
          map((users) => CoreActions.LoadUsers({ users })),
          catchError((err) => {
            const error = new Error();
            error.message = err.message;
            CoreActions.AddError({ error: error });
            return of(CoreActions.LoadUsers({ users: [] as User[] }));
          })
        )
      )
    )
  );

  apartamentsGetAll$ = createEffect(() =>
    this.action$.pipe(
      ofType(CoreActions.BeginLoadingApartaments),
      switchMap(() =>
        this._service.getAllApartaments().pipe(
          map((apartamente) => CoreActions.LoadApartaments({ apartamente })),
          catchError((err) => {
            const error = new Error();
            error.message = err.message;
            CoreActions.AddError({ error });
            return of(CoreActions.LoadApartaments({ apartamente: [] }));
          })
        )
      )
    )
  );

  insertApartament$ = createEffect(() => {
    return this.action$.pipe(
      ofType(CoreActions.CreateApartament),
      switchMap((action) =>
        this._service.createApartament(action.apartament).pipe(
          tap((elem) => console.log(elem)),
          map((app) => CoreActions.AddApartamentToState({ apartament: app })),
          catchError((err) => {
            const error = new Error();
            error.message = err.message;
            CoreActions.AddError({ error });
            return of(CoreActions.ApartamentDoNothing());
          })
        )
      )
    );
  });

  deleteApartament$ = createEffect(() =>
    this.action$.pipe(
      ofType(CoreActions.DeleteApartament),
      switchMap((action) =>
        this._service.deleteApartament(action.id).pipe(
          map((apartament) => CoreActions.DeleteFromApartament({ apartament })),
          catchError((err) => {
            const error = new Error();
            error.message = err.message;
            CoreActions.AddError({ error });
            return of(CoreActions.LoadApartaments({ apartamente: [] }));
          })
        )
      )
    )
  );
}
