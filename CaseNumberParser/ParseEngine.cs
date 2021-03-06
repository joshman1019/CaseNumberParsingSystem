﻿using System;

namespace CaseNumberParser
{
    public class ParseEngine
    {
        public string ReturnParsed(string input, CaseNumberFormat caseFormat, YearFormat yearFormat)
        {
            try
            {
                string year = ReturnYear(input, yearFormat);
                string caseType = ReturnCaseType(input, yearFormat, caseFormat);
                string sequence = ReturnSequence(input, yearFormat, caseFormat);
                if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(caseType) || string.IsNullOrEmpty(sequence))
                    return string.Empty;

                return $"{year} {caseType} {sequence}";
            }
            catch (Exception)
            {
                return string.Empty; 
            }

        }

        private string ReturnYear(string input, YearFormat format)
        {
            switch (format)
            {
                case YearFormat.TwoDigit:
                    return input.Substring(0, 2); 
                case YearFormat.FourDigit:
                    return input.Substring(0, 4); 
                default:
                    return string.Empty; 
            }
        }

        private string ReturnCaseType(string input, YearFormat yearFormat, CaseNumberFormat caseNumberFormat)
        {
            switch (yearFormat)
            {
                case YearFormat.FourDigit:
                    switch (caseNumberFormat)
                    {
                        case CaseNumberFormat.OneDigitCaseType:
                            return input.Substring(5, 1).ToUpper();
                        case CaseNumberFormat.TwoDigitCaseType:
                            return input.Substring(5, 2).ToUpper();
                        case CaseNumberFormat.ThreeDigitCaseType:
                            return input.Substring(5, 3).ToUpper();
                        default:
                            return string.Empty;
                    }
                case YearFormat.TwoDigit:
                    switch (caseNumberFormat)
                        {
                            case CaseNumberFormat.OneDigitCaseType:
                                return input.Substring(3, 1).ToUpper(); 
                            case CaseNumberFormat.TwoDigitCaseType:
                                return input.Substring(3, 2).ToUpper();
                            case CaseNumberFormat.ThreeDigitCaseType:
                                return input.Substring(3, 3).ToUpper();
                            default:
                                return string.Empty; 
                        }
                default:
                    return string.Empty; 
            }
        }

        private string ReturnSequence(string input, YearFormat yearFormat, CaseNumberFormat caseNumberFormat)
        {
            switch (yearFormat)
            {
                case YearFormat.TwoDigit:
                    switch (caseNumberFormat)
                    {
                        case CaseNumberFormat.OneDigitCaseType:
                            return input.Substring(5).PadLeft(6, '0'); 
                        case CaseNumberFormat.TwoDigitCaseType:
                            return input.Substring(6).PadLeft(6, '0');
                        case CaseNumberFormat.ThreeDigitCaseType:
                            return input.Substring(7).PadLeft(6, '0');
                        default:
                            return string.Empty; 
                    }
                case YearFormat.FourDigit:
                    switch (caseNumberFormat)
                    {
                        case CaseNumberFormat.OneDigitCaseType:
                            return input.Substring(7).PadLeft(8, '0'); 
                        case CaseNumberFormat.TwoDigitCaseType:
                            return input.Substring(8).PadLeft(9, '0');
                        case CaseNumberFormat.ThreeDigitCaseType:
                            return input.Substring(9).PadLeft(10, '0');
                        default:
                            return string.Empty; 
                    }
                default:
                    return string.Empty; 
            }
        }
    }
}
