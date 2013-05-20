using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public enum ListStyleType { BulletList1 = 1, BulletList2 = 2, BulletList3 = 3, NumberList1 = 4, NumberList2 = 5, NumberList3 = 6, none=7}
    public class ValueListStyleType : ValueStyle
    {
        private ListStyleType value;

        public ListStyleType Value
        {
            get { return value; }
            set {
                this.value = value;
                base.ChangeValue(value);

            }
        }
        public override void ChangeValue(ListStyleType val)
        {
            Value = val;
            base.ChangeValue(value);
        }
        public override object GetValue()
        {
            return Value;
        }
    }

    public static class ListOfStyleType
    {
        public static ListStyleType GetListStyleType(string v)
        {
            switch (v.ToLower().Trim())
            {
                case "circle":
                    return ListStyleType.BulletList1;
                case "armenian":
                    return ListStyleType.NumberList3;
                case "cjk-ideographic":
                    return ListStyleType.NumberList3;
                case "decimal":
                    return ListStyleType.NumberList1;
                case "decimal-leading-zero":
                    return ListStyleType.NumberList1;
                case "disc":
                    return ListStyleType.BulletList1;
                case "georgian":
                    return ListStyleType.NumberList3;
                case "hebrew":
                    return ListStyleType.NumberList3;
                case "hiragana":
                    return ListStyleType.NumberList3;
                case "hiragana-iroha":
                    return ListStyleType.NumberList1;
                case "inherit":
                    return ListStyleType.BulletList1;
                case "katakana":
                    return ListStyleType.NumberList1;
                case "katakana-iroha":
                    return ListStyleType.NumberList1;
                case "lower-alpha":
                    return ListStyleType.NumberList3;
                case "ower-greek":
                    return ListStyleType.NumberList3;
                case "lower-latin":
                    return ListStyleType.NumberList3;
                case "lower-roman":
                    return ListStyleType.NumberList2;
                case "square":
                    return ListStyleType.BulletList3;
                case "upper-alpha":
                    return ListStyleType.NumberList3;
                case "upper-latin":
                    return ListStyleType.NumberList3;
                case "upper-roman":
                    return ListStyleType.NumberList2;
                case "none":
                    return ListStyleType.none;               
                default:
                    return ListStyleType.BulletList1;
               
            }
        }
        public static MigraDoc.DocumentObjectModel.ListType GetListStyleType(ListStyleType v)
        {
            switch (v)
            {
                case ListStyleType.BulletList1:
                    return MigraDoc.DocumentObjectModel.ListType.BulletList1;
                case ListStyleType.BulletList2:
                    return MigraDoc.DocumentObjectModel.ListType.BulletList2;
                case ListStyleType.BulletList3:
                    return MigraDoc.DocumentObjectModel.ListType.BulletList3;
                case ListStyleType.NumberList1:
                    return MigraDoc.DocumentObjectModel.ListType.NumberList1;
                case ListStyleType.NumberList2:
                    return MigraDoc.DocumentObjectModel.ListType.NumberList2;
                case ListStyleType.NumberList3:
                    return MigraDoc.DocumentObjectModel.ListType.NumberList3;
                default:
                    return MigraDoc.DocumentObjectModel.ListType.BulletList1;
            }
        }
    }

}
