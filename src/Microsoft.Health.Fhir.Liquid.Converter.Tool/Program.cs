﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using CommandLine;
using CommandLine.Text;
using Microsoft.Health.Fhir.Liquid.Converter.Tool.Models;

namespace Microsoft.Health.Fhir.Liquid.Converter.Tool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var parseResult = Parser.Default.ParseArguments<ConverterOptions, PullTemplateOptions, PushTemplateOptions>(args);
            parseResult
                .WithParsed<ConverterOptions>(options => ConverterLogicHandler.Convert(options))
                .WithParsed<PullTemplateOptions>(options => TemplateLogicHandler.Pull(options))
                .WithParsed<PushTemplateOptions>(options => TemplateLogicHandler.Push(options))
                .WithNotParsed((errors) => HandleOptionsParseError(parseResult));
        }

        private static void HandleOptionsParseError(ParserResult<object> parseResult)
        {
            var usageText = HelpText.RenderUsageText(parseResult);
            Console.WriteLine(usageText);
        }
    }
}
