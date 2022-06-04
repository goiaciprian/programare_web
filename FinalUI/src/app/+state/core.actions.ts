import { createAction, props } from '@ngrx/store';
import { Apartament } from '../models/apartament.model';
import { ApartamentDTO } from '../models/apartamentdto.model';
import { Error } from '../models/error.model';
import { User } from '../models/user.model.ts';

export const BeginLoadingUser = createAction(
  '[Load Users] Get users form service'
);

export const LoadUsers = createAction(
  '[Load Users Success] Successfuly loaded users',
  props<{ users: User[] }>()
);
export const AddError = createAction(
  '[Add Error] Adding error',
  props<{ error: Error }>()
);

export const BeginLoadingApartaments = createAction(
  '[Load Apartaments] Get apartaments from service'
);

export const LoadApartaments = createAction(
  '[Load Apartaments] Successfuly loaded apartaments',
  props<{ apartamente: Apartament[] }>()
);

export const SetSelectedUser = createAction(
  '[Set Selected User] Set logged in user',
  props<{ userId: number | undefined }>()
);

export const CreateApartament = createAction(
  '[Apartaments] Create apartament',
  props<{ apartament: ApartamentDTO }>()
);
export const DeleteApartament = createAction(
  '[Apartaments] Delete apartament',
  props<{ id: number }>()
);

export const ApartamentDoNothing = createAction('[Apartaments] Do nothing');

export const AddApartamentToState = createAction(
  '[Apartaments] Add apartament to state',
  props<{ apartament: Apartament }>()
);

export const DeleteFromApartament = createAction(
  '[Apartaments] Delete from apartaments',
  props<{ apartament: Apartament }>()
);
