// Copyright © 2017 - 2021 Chocolatey Software, Inc
// Copyright © 2011 - 2017 RealDimensions Software, LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
//
// You may obtain a copy of the License at
//
// 	http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace chocolatey.tests.infrastructure.app.commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using chocolatey.infrastructure.app.attributes;
    using chocolatey.infrastructure.app.commands;
    using chocolatey.infrastructure.app.configuration;
    using chocolatey.infrastructure.app.services;
    using chocolatey.infrastructure.commandline;
    using Moq;
    using Should;

    public class ChocolateySearchCommandSpecs
    {
        [ConcernFor("search")]
        public abstract class ChocolateySearchCommandSpecsBase : TinySpec
        {
            protected ChocolateySearchCommand command;
            protected Mock<IChocolateyPackageService> packageService = new Mock<IChocolateyPackageService>();
            protected ChocolateyConfiguration configuration = new ChocolateyConfiguration();

            public override void Context()
            {
                configuration.Sources = "bob";
                command = new ChocolateySearchCommand(packageService.Object);
            }
        }

        public class when_implementing_command_for : ChocolateySearchCommandSpecsBase
        {
            private List<string> results;

            public override void Because()
            {
                results = command.GetType().GetCustomAttributes(typeof(CommandForAttribute), false).Cast<CommandForAttribute>().Select(a => a.CommandName).ToList();
            }

            [Fact]
            public void should_not_implement_list()
            {
                results.ShouldNotContain("list");
            }

            [Fact]
            public void should_implement_search()
            {
                results.ShouldContain("search");
            }

            [Fact]
            public void should_implement_find()
            {
                results.ShouldContain("find");
            }
        }

        public class when_configurating_the_argument_parser_for_search_command : ChocolateySearchCommandSpecsBase
        {
            private OptionSet optionSet;

            public override void Context()
            {
                base.Context();
                optionSet = new OptionSet();
                configuration.CommandName = "search";
            }

            public override void Because()
            {
                command.configure_argument_parser(optionSet, configuration);
            }

            [Fact]
            public void should_add_source_to_the_option_set()
            {
                optionSet.Contains("source").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_source_to_the_option_set()
            {
                optionSet.Contains("s").ShouldBeTrue();
            }

            [Fact]
            public void should_add_prerelease_to_the_option_set()
            {
                optionSet.Contains("prerelease").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_prerelease_to_the_option_set()
            {
                optionSet.Contains("pre").ShouldBeTrue();
            }

            [Fact]
            public void should_add_includeprograms_to_the_option_set()
            {
                optionSet.Contains("includeprograms").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_includeprograms_to_the_option_set()
            {
                optionSet.Contains("i").ShouldBeTrue();
            }

            [Fact]
            public void should_add_allversions_to_the_option_set()
            {
                optionSet.Contains("allversions").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_allversions_to_the_option_set()
            {
                optionSet.Contains("a").ShouldBeTrue();
            }

            [Fact]
            public void should_add_user_to_the_option_set()
            {
                optionSet.Contains("user").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_user_to_the_option_set()
            {
                optionSet.Contains("u").ShouldBeTrue();
            }

            [Fact]
            public void should_add_password_to_the_option_set()
            {
                optionSet.Contains("password").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_password_to_the_option_set()
            {
                optionSet.Contains("p").ShouldBeTrue();
            }
        }

        [NUnit.Framework.TestFixture("search")]
        [NUnit.Framework.TestFixture("find")]
        public class when_configurating_the_argument_parser : ChocolateySearchCommandSpecsBase
        {
            private OptionSet optionSet;

            public when_configurating_the_argument_parser(string commandName)
            {
                configuration.CommandName = commandName;
            }

            public override void Context()
            {
                base.Context();
                optionSet = new OptionSet();
            }

            public override void Because()
            {
                command.configure_argument_parser(optionSet, configuration);
            }

            [Fact]
            public void should_add_source_to_the_option_set()
            {
                optionSet.Contains("source").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_source_to_the_option_set()
            {
                optionSet.Contains("s").ShouldBeTrue();
            }

            [Fact]
            public void should_add_prerelease_to_the_option_set()
            {
                optionSet.Contains("prerelease").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_prerelease_to_the_option_set()
            {
                optionSet.Contains("pre").ShouldBeTrue();
            }

            [Fact]
            public void should_add_includeprograms_to_the_option_set()
            {
                optionSet.Contains("includeprograms").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_includeprograms_to_the_option_set()
            {
                optionSet.Contains("i").ShouldBeTrue();
            }

            [Fact]
            public void should_add_allversions_to_the_option_set()
            {
                optionSet.Contains("allversions").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_allversions_to_the_option_set()
            {
                optionSet.Contains("a").ShouldBeTrue();
            }

            [Fact]
            public void should_add_user_to_the_option_set()
            {
                optionSet.Contains("user").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_user_to_the_option_set()
            {
                optionSet.Contains("u").ShouldBeTrue();
            }

            [Fact]
            public void should_add_password_to_the_option_set()
            {
                optionSet.Contains("password").ShouldBeTrue();
            }

            [Fact]
            public void should_add_short_version_of_password_to_the_option_set()
            {
                optionSet.Contains("p").ShouldBeTrue();
            }
        }

        public class when_handling_additional_argument_parsing : ChocolateySearchCommandSpecsBase
        {
            private readonly IList<string> unparsedArgs = new List<string>();
            private readonly string source = "https://somewhereoutthere";
            private Action because;

            public override void Context()
            {
                base.Context();
                unparsedArgs.Add("pkg1");
                unparsedArgs.Add("pkg2");
                configuration.Sources = source;
            }

            public override void Because()
            {
                because = () => command.handle_additional_argument_parsing(unparsedArgs, configuration);
            }

            [Fact]
            public void should_set_unparsed_arguments_to_configuration_input()
            {
                because();
                configuration.Input.ShouldEqual("pkg1 pkg2");
            }

            [Fact]
            public void should_leave_source_as_set()
            {
                configuration.ListCommand.LocalOnly = false;
                because();
                configuration.Sources.ShouldEqual(source);
            }
        }

        public class when_noop_is_called_with_search_command : ChocolateySearchCommandSpecsBase
        {
            public override void Context()
            {
                base.Context();
                configuration.CommandName = "search";
            }

            public override void Because()
            {
                command.noop(configuration);
            }

            [Fact]
            public void should_call_service_list_noop()
            {
                packageService.Verify(c => c.list_noop(configuration), Times.Once);
            }
        }

        public class when_noop_is_called : ChocolateySearchCommandSpecsBase
        {
            public override void Because()
            {
                command.noop(configuration);
            }

            [Fact]
            public void should_call_service_list_noop()
            {
                packageService.Verify(c => c.list_noop(configuration), Times.Once);
            }

            [Fact]
            public void should_not_report_any_warning_messages()
            {
                MockLogger.Messages.Keys.ShouldNotContain("Warn");
            }
        }

        public class when_run_is_called_with_search_command : ChocolateySearchCommandSpecsBase
        {
            public override void Context()
            {
                base.Context();
                configuration.CommandName = "search";
            }

            public override void Because()
            {
                command.run(configuration);
            }

            [Fact]
            public void should_call_service_list_run()
            {
                packageService.Verify(c => c.list_run(configuration), Times.Once);
            }
        }

        public class when_run_is_called : ChocolateySearchCommandSpecsBase
        {
            public override void Because()
            {
                command.run(configuration);
            }

            [Fact]
            public void should_call_service_list_run()
            {
                packageService.Verify(c => c.list_run(configuration), Times.Once);
            }

            [Fact]
            public void should_not_report_any_warning_messages()
            {
                MockLogger.Messages.Keys.ShouldNotContain("Warn");
            }
        }

        [NUnit.Framework.TestFixture("search")]
        [NUnit.Framework.TestFixture("find")]
        public class when_outputting_help_message : ChocolateySearchCommandSpecsBase
        {
            public when_outputting_help_message(string commandName)
            {
                configuration.CommandName = commandName;
            }

            public override void Because()
            {
                command.help_message(configuration);
            }
        }
    }
}
