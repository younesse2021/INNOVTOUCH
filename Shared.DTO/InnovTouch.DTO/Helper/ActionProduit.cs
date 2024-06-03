using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO.InnovTouch.DTO.Models.Helper
{
    public enum ActionProduit
    {
        Rien,
        Remise,
        Retrait,
        Modifie,
        Supprime,
        RemiseValide,
        RetraitValide
    }
    public class MessageDto<T> where T : class
    {
        public int Id { get; set; } = 0;
        public T? Value { get; set; }
        public bool IsError { get; set; } = false;
        public string Message { get; set; } = "";
    }
}
