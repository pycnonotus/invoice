import { Pipe, PipeTransform } from '@angular/core';
import { Status } from '../models/status';

@Pipe({
  name: 'statusName'
})
export class StatusNamePipe implements PipeTransform {

  transform(value: Status) : string {
    switch (value) {
      case Status.Paid:
        return "Paid"
      case Status.Unpaid:
        return "Unpaid";
    }
  }

}
