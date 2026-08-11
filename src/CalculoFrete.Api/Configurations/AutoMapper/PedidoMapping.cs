using AutoMapper;
using CalculoFrete.Api.Models;
using CalculoFrete.Domain;
using CalculoFrete.Domain.Enums;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Api.Configurations.AutoMapper
{
    public class PedidoMappings : Profile
    {
        public PedidoMappings()
        {
            // Domain -> viewmodel
            CreateMap<Pedido, ConsultarPedidoVm>()
                .ForMember(dest => dest.CepDestino, opt => opt.MapFrom(src => src.CepDestino.Numero));

            CreateMap<Produto, ConsultarProdutoVm>();
            CreateMap<Frete, ConsultarFreteVm>();
            CreateMap<PrazoEntrega, ConsultarPrazoEntregaVm>();

            CreateMap<ItemPedido, ConsultarItemPedidoResumidoVm>()
                .ForMember(dest => dest.Frete, opt => opt.MapFrom(src => new ConsultarFreteResumoVm()
                {
                    ModalidadeFrete = src.ModalidadeFrete,
                    Valor = src.Frete.Valor,
                    PrazoEntrega = src.ModalidadeFrete == ModalidadeFrete.Agendado ?
                        src.DataAgendamento.Value.ToString("yyyy-MM-dd") :
                        $"De {src.Frete.PrazoEntrega.NumeroMinimoDias} a {src.Frete.PrazoEntrega.NumeroMaximoDias} dias"
                }));

            CreateMap<ItemPedido, CalcularFreteItemPedidoResumidoVm>()
                .ForMember(dest => dest.Frete, opt => opt.MapFrom(src => new ConsultarFreteResumoVm()
                {
                    ModalidadeFrete = src.ModalidadeFrete,
                    Valor = src.Frete.Valor,
                    PrazoEntrega = src.ModalidadeFrete == ModalidadeFrete.Agendado ?
                        src.DataAgendamento.Value.ToString("dd/MM/yyyy") :
                        $"De {src.Frete.PrazoEntrega.NumeroMinimoDias} a {src.Frete.PrazoEntrega.NumeroMaximoDias} dias"
                }));

            // Viewmodel -> domain

        }
    }
}
