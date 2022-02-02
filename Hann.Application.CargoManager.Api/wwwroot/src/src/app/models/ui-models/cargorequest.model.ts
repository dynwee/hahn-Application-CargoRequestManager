export interface CargoRequest{
  id: number,
  customerName: string,
  deliveryDate: string,
  deliveryTerminalId: number,
  dropOffDate: string,
  dropOffTerminalId: number,
  emailAddress: string,
  estimatedWeight: string,
  itemDescription: string,
  itemSummary: string,
  phoneNumber: string,
  status:string
}
