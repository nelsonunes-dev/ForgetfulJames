﻿using ForgetfulJames.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgetfulJames.Dto.Entities
{
    public class ToDoDto
    {
        public DateTime DueDate { get; set; }
        public byte[] Image { get; set; } = Array.Empty<byte>();
        public string Name { get; set; } = string.Empty;
        public ToDoImportance Starred { get; set; } = ToDoImportance.Normal;
        public string UserId { get; set; } = string.Empty;
    }
}
