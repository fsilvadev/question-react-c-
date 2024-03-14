// TESTE SELEÇÃO - REACT

// CÓDIGO COM PROBLEMA

// import React from 'react';
// class Produtos extends React.Component {
// constructor(props) {
// super(props);
// this.state = { produtos: [] };
// }
// handleAddClick() {
// const { produtos } = this.state;
// const novoProduto = { id: 0, descricao: 'Banana' };
// produtos.push(novoProduto);
// this.setState({ produtos });
// }
// render() {
// const { produtos } = this.state;
// return (
// <div>
// <ul>
// {produtos.map(p => <li>{p.descricao}</li>)}
// </ul>
// <button onClick={this.handleAddClick}>+</button>
// </div>
// );


//SOLUÇÃO

import React from 'react';

interface Produto { // Tipagem produto
  id: number;
  descricao: string;
}

interface ProdutosState { // Tipagem componente Produtos
  produtos: Produto[];
}

class Produtos extends React.Component<{}, ProdutosState> {
  constructor(props: {}) {
    super(props);
    this.state = { produtos: []};
    this.handleAddClick = this.handleAddClick.bind(this);
  }
  
  handleAddClick() {
    const { produtos } = this.state;
    const novoProduto: Produto = { id: produtos.length, descricao: 'Banana' };
    produtos.push(novoProduto);
    this.setState({ produtos });
  }
  render() {
    const { produtos } = this.state;
    return (
    <div>
      <ul>
      {produtos.map(p => <li key={p.id}>{p.descricao}</li>)}
      </ul>
      <button onClick={this.handleAddClick}>+</button>
    </div>
    );
  }
}

export default Produtos;


// RESUMO DOS PROBLEMAS ENCONTRADOS

// Na class Produtos a falta de tipagem do componente

// Na inicialização do constructor a falta da tipagem da props

// Falta de interface para tipagem do produto

// No constructor vincular o metodo handlAddClick ao contexto do componente.

// Dentro da função handleAddClick a falta de tipagem do novoProduto

// id não de forma dinâmica(chumbado)

// E no final o uso do export default Produtos, para utilizar como componente.

