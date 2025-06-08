export class Produto {
  constructor(
    public id: string,
    public nome: string,
    public preco: number,
    public quantidade: number,
    public creationTime: string,
    public lastModifiedTime?: string
  ) {}
}
