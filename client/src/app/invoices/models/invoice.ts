import { Products } from './products';
import { Status } from './status';
import { Customer } from "src/app/customers/models/customer";

export interface Invoice {
  id: string;
  customer : Customer;
  // products : Products[];
  amount: number;
  status: Status;
}


