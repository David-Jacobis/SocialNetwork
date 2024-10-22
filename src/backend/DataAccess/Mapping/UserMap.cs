using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.ToTable("TAB_MAP_USUARIO"); // Nome da tabela

            builder.HasKey(e => e.IdUsu);

            builder.Property(e => e.IdUsu)
                .HasColumnName("ID_USU")
                .HasColumnType("NUMBER(10,0)")
                .IsRequired();

            builder.Property(e => e.NomUsu)
                .HasColumnName("NOM_USU")
                .HasColumnType("VARCHAR2(100 BYTE)")
                .HasMaxLength(100);

            builder.Property(e => e.CodAceUsu)
                .HasColumnName("COD_ACE_USU")
                .HasColumnType("VARCHAR2(20 BYTE)")
                .HasMaxLength(20);

            builder.Property(e => e.DesEmailUsu)
                .HasColumnName("DES_EMAIL_USU")
                .HasColumnType("VARCHAR2(100 BYTE)")
                .HasMaxLength(100);

            builder.Property(e => e.CodPerUsu)
                .HasColumnName("COD_PER_USU")
                .HasColumnType("VARCHAR2(1 BYTE)")
                .HasMaxLength(1);

            builder.Property(e => e.IndStaReg)
                .HasColumnName("IND_STA_REG")
                .HasColumnType("VARCHAR2(1 BYTE)")
                .HasMaxLength(1);

            builder.Property(e => e.DatIniCad)
                .HasColumnName("DAT_INI_CAD")
                .HasColumnType("DATE");

            builder.Property(e => e.DatFimCad)
                .HasColumnName("DAT_FIM_CAD")
                .HasColumnType("DATE")
                .HasDefaultValueSql("TO_DATE('31129999','DDMMYYYY')");

            builder.Property(e => e.DatUltAlt)
                .HasColumnName("DAT_ULT_ALT")
                .HasColumnType("DATE");
        }
    }
}
