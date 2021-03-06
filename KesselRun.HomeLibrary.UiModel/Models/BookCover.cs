﻿using KesselRun.HomeLibrary.Mapper.MappingTypeContracts;
using KesselRun.HomeLibrary.UiModel.Enums;

namespace KesselRun.HomeLibrary.UiModel.Models
{
    public class BookCover : IMapFrom<Model.BookCover>
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Edition Edition { get; set; }
        public byte[] Cover { get; set; }
    }
}
