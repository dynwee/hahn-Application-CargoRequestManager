import { DeliveryTerminal } from "./deliveryterminal.model";
import { DropOffTerminal } from "./dropoffterminal.model";

export interface CargoRequestDetail{
  id: number,
  customerName: string,
  deliveryDate: string,
  deliveryTerminal: DeliveryTerminal,
  deliveryTerminalId: number,
  dropOffDate: string,
  dropOffTerminal: DropOffTerminal,
  dropOffTerminalId: number,
  emailAddress: string,
  estimatedWeight: string,
  itemDescription: string,
  itemSummary: string,
  phoneNumber: string,
  status:string
}
