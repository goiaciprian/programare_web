import { User } from '../models/user.model.ts';
import { Error } from '../models/error.model';
import { Apartament } from '../models/apartament.model';

export interface CoreState {
  users: User[];
  errors: Error[];
  selectedUser: number | undefined;
  apartamente: Apartament[];
}

export const initialState: CoreState = {
  users: [],
  errors: [],
  selectedUser: undefined,
  apartamente: [],
};
